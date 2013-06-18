define('model.mapper',
['model'],
    function (model) {
        var courtmember = {
            getDtoId: function(dto) {
                return dto.userId;
            },
            fromDto: function(dto, item) {
                item = item || new model.CourtMember().userId(dto.userId);
                item.username(dto.username);
                item.firstName(dto.firstName);
                item.lastName(dto.lastName);
                item.middleName(dto.middleName);
                item.phone(dto.phone);
                item.email(dto.email);
                item.isCertified(dto.isCertified);
                item.isAvilable(dto.isAvilable);
                item.password(dto.password);
                return item;
            }
        },
        
       courtmemberbrief = {
           getDtoId: function (dto) { return dto.userId; },
           fromDto: function (dto, item) {
               item = item || new model.CourtMemberBrief().userId(dto.userId);
               item.fullName(dto.fullName);
               item.roleName(dto.roleName);
               item.email(dto.email);
               return item;
           }
       };

        return
        {
            courtmember: courtmember,
            courtmemberbrief: courtmemberbrief
        };
    }
);