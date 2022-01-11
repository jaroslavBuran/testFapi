$(function () {
    $(document).ready(function () {
        calculatePrice();
    });

    $('#quantity').on("change", function () {
        calculatePrice();
    });

    $('#price').on("change", function () {
        calculatePrice();
    });

    function calculatePrice() {
        var quantity = $('#quantity').val();
        var price = $('#price').val();

        if (quantity != "" && price != "") {
            var totalPrice = quantity * price;
        }
        $('#total').val(totalPrice.toFixed(2));
    }
});