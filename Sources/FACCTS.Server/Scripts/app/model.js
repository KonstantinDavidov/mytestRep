define("model",
    ["model.courtmember",
    "model.courtmemberbrief"],
    function (courtmember, courtmemberbrief) {
        var
            model = {
                CourtMember: courtmember,
                CourtMemberBrief: courtmemberbrief
            };

        model.setDataContext = function (dc) {
            // Model's that have navigation properties 
            // need a reference to the datacontext.
            model.CourtMember.datacontext(dc);
        };

        return model;
    }
    );