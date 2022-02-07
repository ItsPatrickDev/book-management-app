const pageJS = {
    setPage: function () {
        $(".removeBook").on("click", function () {
            var bookId = $(this).closest("tr").attr("data-id");
            var shelfId = $(this).closest("table").attr("data-shelfId");
            pageJS.showRemoveShelfModal(bookId, shelfId);
        })
    },

    showRemoveShelfModal: function (bookId, shelfId) {
        $("#removeBookFromShelfModal").modal("show");
        $("#removeBookFromShelf").on("click", function () {
            pageJS.removeFromShelf(bookId, shelfId);
        })
    },

    removeFromShelf: function (bookId, shelfId) {
        var data = {
            bookId: bookId,
            shelfId: shelfId
        };

        $.ajax({
            url: "RemoveBook",
            data: data,
            method: "post",
            success: function () {
                $("#removeBookFromShelfModal").modal("hide");
                $("table tbody").find(`[data-id='${bookId}']`).remove();
                pageJS.showIfNoBooks();
            }
        })
    },

    showIfNoBooks: function () {
        if (!$("table tbody").find("tr").length) {
            $("table").remove();
            $(".container").append("<p>No books</p>");
        }
    },

    goToShelves: function (id) {
        window.location.href = "/Shelves/Index";
    },
}