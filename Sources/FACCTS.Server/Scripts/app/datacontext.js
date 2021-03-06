﻿define('datacontext',
    ['jquery', 'underscore', 'ko', 'model', 'model.mapper', 'dataservice', 'config', 'utils'],
    function ($, _, ko, model, modelmapper, dataservice, config, utils) {
        var logger = config.logger,
            //getCurrentUserId = function () {
            //    return config.currentUser().id();
            //},
            itemsToArray = function (items, observableArray, filter, sortFunction) {
                // Maps the memo to an observableArray, 
                // then returns the observableArray
                if (!observableArray) return;

                // Create an array from the memo object
                var underlyingArray = utils.mapMemoToArray(items);

                if (filter) {
                    underlyingArray = _.filter(underlyingArray, function (o) {
                        var match = filter.predicate(filter, o);
                        return match;
                    });
                }
                if (sortFunction) {
                    underlyingArray.sort(sortFunction);
                }
                //logger.info('Fetched, filtered and sorted ' + underlyingArray.length + ' records');
                observableArray(underlyingArray);
            },
            mapToContext = function (dtoList, items, results, mapper, filter, sortFunction) {
                // Loop through the raw dto list and populate a dictionary of the items
                items = _.reduce(dtoList, function (memo, dto) {
                    var id = mapper.getDtoId(dto);
                    var existingItem = items[id];
                    memo[id] = mapper.fromDto(dto, existingItem);
                    return memo;
                }, {});
                itemsToArray(items, results, filter, sortFunction);
                //logger.success('received with ' + dtoList.length + ' elements');
                return items; // must return these
            },
            EntitySet = function (getFunction, mapper, nullo, updateFunction) {
                var items = {},
                    // returns the model item produced by merging dto into context
                    mapDtoToContext = function (dto) {
                        var id = mapper.getDtoId(dto);
                        var existingItem = items[id];
                        items[id] = mapper.fromDto(dto, existingItem);
                        return items[id];
                    },
                    add = function (newObj) {
                        items[newObj.id()] = newObj;
                    },
                    removeById = function (id) {
                        delete items[id];
                    },
                    getLocalById = function (id) {
                        // This is the only place we set to NULLO
                        return !!id && !!items[id] ? items[id] : nullo;
                    },
                    getAllLocal = function () {
                        return utils.mapMemoToArray(items);
                    },
                    getData = function (options) {
                        return $.Deferred(function (def) {
                            debugger;
                            var results = options && options.results,
                                sortFunction = options && options.sortFunction,
                                filter = options && options.filter,
                                forceRefresh = options && options.forceRefresh,
                                param = options && options.param,
                                getFunctionOverride = options && options.getFunctionOverride;

                            getFunction = getFunctionOverride || getFunction;

                            // If the internal items object doesnt exist, 
                            // or it exists but has no properties, 
                            // or we force a refresh
                            if (forceRefresh || !items || !utils.hasProperties(items)) {
                                getFunction({
                                    success: function (dtoList) {
                                        debugger;
                                        items = mapToContext(dtoList, items, results, mapper, filter, sortFunction);
                                        def.resolve(results);
                                    },
                                    error: function (response) {
                                        logger.error(config.toasts.errorGettingData);
                                        def.reject();
                                    }
                                }, param);
                            } else {
                                itemsToArray(items, results, filter, sortFunction);
                                def.resolve(results);
                            }
                        }).promise();
                    },
                    updateData = function (entity, callbacks) {

                        var entityJson = ko.toJSON(entity);

                        return $.Deferred(function (def) {
                            if (!updateFunction) {
                                logger.error('updateData method not implemented');
                                if (callbacks && callbacks.error) { callbacks.error(); }
                                def.reject();
                                return;
                            }

                            updateFunction({
                                success: function (response) {
                                    logger.success(config.toasts.savedData);
                                    entity.dirtyFlag().reset();
                                    if (callbacks && callbacks.success) { callbacks.success(); }
                                    def.resolve(response);
                                },
                                error: function (response) {
                                    logger.error(config.toasts.errorSavingData);
                                    if (callbacks && callbacks.error) { callbacks.error(); }
                                    def.reject(response);
                                    return;
                                }
                            }, entityJson);
                        }).promise();
                    };

                return {
                    mapDtoToContext: mapDtoToContext,
                    add: add,
                    getAllLocal: getAllLocal,
                    getLocalById: getLocalById,
                    getData: getData,
                    removeById: removeById,
                    updateData: updateData
                };
            },

            //----------------------------------
            // Repositories
            //
            // Pass: 
            //  dataservice's 'get' method
            //  model mapper
            //----------------------------------
            courtmembers = new EntitySet(dataservice.courtmember.getCourtMemberBriefs, modelmapper.courtmemberbrief, model.CourtMember.Nullo);

        // extend courtmember enttityset 
        courtmembers.getCourtmemberById = function (id, callbacks, forceRefresh) {
            return $.Deferred(function (def) {
                var courtmember;// = courtmembers.getLocalById(id);
                if (forceRefresh) {
                    // if nullo or brief, get fresh from database
                    dataservice.courtmember.getCourtMemberById({
                        success: function (dto) {
                            // updates the courtmember returned from getLocalById() above
                            //var id = modelmapper.courtmember.getDtoId(dto);
                            debugger;
                            courtmember = modelmapper.courtmember.fromDto(dto, courtmember);
                            if (callbacks && callbacks.success) { callbacks.success(courtmember); }
                            def.resolve(dto);
                        },
                        error: function (response) {
                            logger.error('oops! could not retrieve data ' + id);
                            if (callbacks && callbacks.error) { callbacks.error(response); }
                            def.reject(courtmember);
                        }
                    },
                    id);
                }
                else {
                    if (callbacks && callbacks.success) { callbacks.success(session); }
                    def.resolve(session);
                }
            }).promise();
        };

        var datacontext = {
            courtmembers: courtmembers
        };

        // We did this so we can access the datacontext during its construction
        model.setDataContext(datacontext);

        return datacontext;
    });