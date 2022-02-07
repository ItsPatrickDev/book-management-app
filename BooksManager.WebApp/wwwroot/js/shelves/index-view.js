const pageJS = {
    setPage: function () {
        $(".shelfView-item").on("click", function () {
            var id = $(this).closest(".grid-item").attr("data-id");
            pageJS.goToShelfView(id);
        })

        $(".removeShelf-item").on("click", function () {
            var id = $(this).closest(".grid-item").attr("data-id");
            pageJS.showRemoveShelfModal(id);
        })
    },

    showRemoveShelfModal: function (id) {
        $("#removeShelfModal").modal("show");
        $("#removeShelf").on("click", function () {
            pageJS.removeShelf(id);           
        })
    },

    removeShelf: function (id) {
        var data = {
            id: id
        };

        $.ajax({
            url: "Shelves/Remove",
            data: data,
            method: "post",
            success: function () {              
                $("#" + id).remove();        
                $("#removeShelfModal").modal("hide");
                pageJS.showIfNoShelves();
            },
            error: function (err) {
                console.log(err.responseText);
            }
        })
    },

    showIfNoShelves: function () {
        if (!$(".container-grid").find(".grid-item").length) {
            $(".container-grid").remove();
            $(".info-container").parent().append("<p>No shelves</p>");
        }
    },

    goToShelfView: function (id) {
        window.location.href = "/Shelves/Shelf?id=" + id;
    },
}