// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(function () {
//    var PlaceHolderElement = $('#PlaceHolderHere');
//    $('button[data-toggle="ajax-modal"]').click(function (event) {
//        var url = $(this).data('url');
//        $.get(url).done(function (data) {
//            PlaceHolderElement.html(data);
//            PlaceHolderElement.find('.modal').modal('show');
//        })
//    })

//})

//$(function () {
//    $("#EmpGrid .details").click(function () {
//        var Id = $(this).closest("tr").find("td").eq(0).html();
//        $.ajax({
//            type: "Post",
//            url: "/Employee/Details",
//            data: { "id": Id },
//            success: function (response) {
//                $("#partialModal").find(".modal-body").html(response);
//                $("#partialModal").modal('show');
//            },
//            failure: function (response) {
//                alert(response.responseText);
//            },
//            error: function (response) {
//                alert(response.responseText);
//            }
//        });
//    });
//});