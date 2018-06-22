$(function () {
    $.post("/ashx/bookcomment.ashx", { bookid: bookid }, function (data) {
        for (var key in data) {
            $("#comment").append("<tr><td>" + data[key].CreateDateTime  + ":" + data[key].Msg + "</td></tr>")


        }


    }, "json")

    $("#btnAddComment").click(function () {
        if ($("txtcomment").val() != "") {

            $.post("/ashx/bookcomment.ashx", { bookid: bookid, msg: $("#txtComment").val() }, function (data) {
                $("#txtComment").val("");
                $("#comment").html("");
                $.post("/ashx/bookcomment.ashx", { bookid: bookid }, function (data) {
                    for (var key in data) {
                        console.log(data[key]);
                        $("#comment").append("<tr><td>" + data[key].CreateDateTime + ":" + data[key].Msg + "</td></tr>")


                    }
                }, "json")

            }, "json")




        }






    })
    $.post("/ashx/bookcomment.ashx", {}, function (data) {

        if (data.Msg != undefined) {
            $("#showLoginInfo").show();
           
        } else {

            $("#showLoginInfo").hide();
            $("#showUserName").html("欢迎"+data.LoginId);
            $("#showUserName").show();
        }

    }, "json"
        
        )


})