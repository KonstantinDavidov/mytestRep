define('model.courtmemberbrief',
    ['ko', 'config'],
    function (ko, config) {
        var CourtMemberBrief = function () {
            var self = this;
            self.fullName = ko.observable(),
            self.roleName = ko.observable(),
            self.userId = ko.observable(),
            self.email = ko.observable()
        }
        return CourtMemberBrief;
    }
    );