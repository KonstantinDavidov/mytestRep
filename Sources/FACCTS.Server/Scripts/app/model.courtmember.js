define('model.courtmember',
    ['ko', 'config'],
    function (ko, config) {
        var CourtMember = function () {
            var self = this;
            self.userId = ko.observable(),
            self.username = ko.observable(),
            self.firstName = ko.observable(),
            self.lastName = ko.observable(),
            self.middleName = ko.observable(),
            self.phone = ko.observable(),
            self.email = ko.observable(),
            self.isCertified = ko.observable(),
            self.isAvilable = ko.observable(),
            self.password = ko.observable()
        }
        var _dc = null;
        // Static member, no access to instances of CourtMember
        CourtMember.datacontext = function (dc) {
            if (dc) { _dc = dc; }
            return _dc;
        }
        CourtMember.prototype = function () {
            var
                dc = CourtMember.datacontext,
                substitute = function () {
                    //return dc()..getLocalSessionFavorite(this.id());
                },
                
                role = function () {
                    //return dc().rooms.getLocalById(this.roomId());
                },

                image = function()
                {
                    //todo
                }
      };

        return CourtMember;
    }
    );