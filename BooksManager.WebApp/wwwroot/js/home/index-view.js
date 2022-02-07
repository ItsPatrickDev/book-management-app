const pageJS = {
    setPage: function () {
        $(".removeBook").click(function () {
            let id = $(this).closest("tr").attr("data-id");
            var book = $(this).closest("tr");
            pageJS.showRemoveBookModal(id, book);
        })

        $(".editBook").click(function () {
            let id = $(this).closest("tr").attr("data-id");
            pageJS.goToEditBook(id);
        })

        $(".addToBookshelf").click(function () {
            let id = $(this).closest("tr").attr("data-id"); 
            pageJS.showAddToShelfModal(id);
        })
    },

    showRemoveBookModal: function (id, book) {
        $("#removeBookModal").modal("show");
        $("#removeBook").on("click", function () {
            pageJS.removeBook(id, book);            
        })
    },

    showAddToShelfModal: function (id) {
        $("#addToBookshelfModal").modal("show");
        $("#confirmAddToBookshelf").on("click", function () {    
            var shelfId = $("#selectedBookshelf option:selected").val();         
            if (shelfId > 0)
                pageJS.addToShelf(id, shelfId);
        });
    }, 

    removeBook: function (id, element) {
        $.ajax({
            url: "/Books/RemoveBook",
            data: {
                id: id
            },
            method: "post",
            success: function (result) {
                $(element).remove();
                $("#removeBookModal").modal("hide");
                pageJS.hideTableIfNoBooks();
            }
        })
    },   

    addToShelf: function (id, shelfId) {
        var data = {
            __RequestVerificationToken: $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val(),
            bookId: id,
            shelfId: shelfId
        };

        $.ajax({
            url: "Shelves/AddBook",
            data: data,
            method: "post",
            success: function () {
                $("#addToBookshelfModal").modal("hide");
                window.location.href = "/Shelves/Shelf?id=" + shelfId;
            },
            error: function (err) {
                $("#addToBookshelfModal").modal("hide");
                pageJS.showModalIfBookExistsInShelf(err);
            }
        });
    },

    setBookFavourite: function (element) {
        var idValue = $(element).closest("tr").attr("data-id");
        var isFav = false;

        if ($(element).hasClass("bi-star"))
            isFav = true;

        $.ajax({
            url: "/Books/SetFavourite",
            data: {
                id: idValue,
                isFavourite: isFav
            },
            method: "post",
            success: function (result) {
                $(element).toggleClass("bi-star-fill bi-star");
            }
        })
    },  

    hideTableIfNoBooks: function () {
        if (!$("#booksTableContainer").find("tbody tr").length) {
            $("#booksTableContainer table").remove();
            $("#content").html("<p>No books</p>");
        }
    },

    goToEditBook: function (id) {
        window.location.href = "/Books/EditBook?id=" + id;
    },

    showModalIfBookExistsInShelf: function (err) {
        $("#alreadyExistsInShelfModal").modal("show");
        $("#alreadyExistsInShelf").text(err.responseJSON.message);
    }
}