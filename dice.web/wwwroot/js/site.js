// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.validDice').on('input', function () {
        $(this).val($(this).val().replace(/[^1-6]/gi, ''));
    });
    $('.validFactor').on('input', function () {
        $(this).val($(this).val().replace(/[^1-5]/gi, ''));
    });
    $('.validInteger').on('input', function () {
        $(this).val($(this).val().replace(/[^0-9]/gi, ''));
    });
    $('#roll-the-dice').click(function () {
        var id = 'display-result';
        var serviceUrl = 'Home/GetDiceRollResult';
        $('#modal-search').modal('show');
        $('#div-error').removeClass('hidden').addClass('hidden');
        var data = {
            'face1': $('#dice-one-face-value').val(),
            'factor1': $('#dice-one-face-factor').val(),
            'face2': $('#dice-two-face-value').val(),
            'factor2': $('#dice-two-face-factor').val(),
            'times': $('#roll-the-dice-times').val()
        };
        if (data.times == '') {
            $('#modal-search').modal('hide');
            $('#div-error').removeClass('hidden');
        }
        else {
            xhrCall(serviceUrl, 'GET', data, LoadData, id);
        }
    });
    var xhrCall = function (url, serviceType, objData, callback, id) {

        $.ajax({
            url: url,
            type: serviceType,
            data: objData,
            cache: false,
            contentType: 'application/json',
            crossdomain: true,
            async: true,
            success: function (data) {


                callback(id, data);
            },
            error: function (error) {

                callback(error);
            }
        });
    }
    var LoadData = function (id, data) {
        $('#' + id).html(data);
        $('#modal-search').modal('hide');
    }

});


