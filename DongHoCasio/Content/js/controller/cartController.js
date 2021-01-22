﻿var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listSP = $('.txtSoLuong');
            var cartList = [];
            $.each(listSP, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    SanPham: {
                        MaSP: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                    
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            

            $.ajax({
                url: '/Cart/DeleteAll',
               
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }

                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { MaSP: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $("button").mouseleave(
            function () {
                $(this).removeClass("hover");
            }
        );
    }
}
cart.init();