(function () {
    QUnit.config.testTimeout = 100000;

    var okAsync = QUnit.okAsync,
        stringformat = QUnit.stringformat;

    var baseUrl = '/FACCTS.Server/Admin/api/courtmembers',
        getMsgPrefix = function (id, rqstUrl) {
            return stringformat(
                ' of courtmember with id=\'{0}\' to \'{1}\'',
                id, rqstUrl);
        },
        onCallSuccess = function (msgPrefix) {
            ok(true, msgPrefix + " succeeded.");
        },
        onError = function (result, msgPrefix) {
            okAsync(false, msgPrefix +
                stringformat(' failed with status=\'{1}\': {2}.',
                    result.status, result.responseText));
        };

    var testCourtMemberLogin = "DemoCourtMember1",
        testUrl,
        testMsgBase,
        testCourtMember,
        origPhone,
        testPhone;

    module('Web API CourtMember update tests',
        {
            setup: function () {
                testUrl = stringformat(
                    '{0}/memberbyname/?username={1}', baseUrl, testCourtMemberLogin);
                testMsgBase = getMsgPrefix(testCourtMemberLogin, testUrl);
            }
        });

    test('Can update the test',
        function () {
            testCourtMember = null;
            stop();
            getTestCourtMember(changeTestCourtMember);
        }
    );

    // Step 1: Get test cm (this fnc is re-used several times)
    function getTestCourtMember(succeed) {
        var msgPrefix = 'GET' + testMsgBase;
        $.ajax({
            type: 'GET',
            url: testUrl,
            success: function (result) {
                onCallSuccess(msgPrefix);
                okAsync(result.username === testCourtMemberLogin,
                    "returned username matches test username.");
                if (typeof succeed !== 'function') {
                    start(); // no 'succeed' callback; end of the line
                    return;
                } else {
                    succeed(result);
                };
            },
            error: function (result) { onError(result, msgPrefix); }
        });
    };

    // Step 2: Change test session and save it
    function changeTestCourtMember(courtmember) {
        testCourtMember = courtmember;
        origPhone = testCourtMember.Phone;
        testPhone = origPhone === "222222" ? "555555" : "222222"; // make it different
        testCourtMember.Phone = testPhone;

        var msgPrefix = 'PUT (change)' + testMsgBase,
            data = JSON.stringify(testCourtMember);
        $.ajax({
            type: 'PUT',
            url: baseUrl,
            data: data,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function () {
                onCallSuccess(msgPrefix);
                getTestCourtMember(confirmUpdated);
            },
            error: function (result) { onError(result, msgPrefix); }
        });
    };

    // Step 3: Confirm test session updated, then call restore
    function confirmUpdated(member) {
        okAsync(member.phone === testPhone, "test courtmember phone was updated ");
        restoreTestCourtMember();
    };

    // Step 4: Restore orig test session in db
    function restoreTestCourtMember() {
        debugger;
        testCourtMember.phone = origPhone;
        var msgPrefix = 'PUT (restore)' + testMsgBase,
            data = JSON.stringify(testCourtMember);

        $.ajax({
            type: 'PUT',
            url: baseUrl,
            data: data,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function () {
                getTestCourtMember(confirmRestored);
            },
            error: function (result) { onError(result, msgPrefix); }
        });
    };

    // Step 5: Confirm test session was restored
    function confirmRestored(member) {
        okAsync(member.code === origPhone, "test courtmember was restored ");
        start();
    };

    /////////////////////

    module('Web API add tests',
        {
            setup: function () {
                testCourtMember = {
                    username: "TEST courtmember " + new Date(),
                    phone: "555555",
                    password: "test",
                };
            }
        });

    test('Can add a test Session',
        function () {
            var msgPrefix = 'POST of new test session to ' + testUrl,
                data = JSON.stringify(testCourtMember);

            stop();
            $.ajax({
                type: 'POST',
                url: baseUrl,
                data: data,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    onCallSuccess(msgPrefix);
                    okAsync(!!result, "returned a newly added courtmember.");
                    debugger;
                    deleteAddedCourtMember(result);
                },
                error: function (result) { onError(result, msgPrefix); }
            });
        }
    );

    function deleteAddedCourtMember(courtMember) {
        var deleteUrl = baseUrl + "/" + courtMember.userId,
            msgPrefix = 'DELETE api call: ' + deleteUrl;
        $.ajax({
            type: 'DELETE',
            url: deleteUrl,
            dataType: 'json',
            success: function () {
                onCallSuccess(msgPrefix);
                start();
            },
            error: function (result) { onError(result, msgPrefix); }
        });
    }

})();