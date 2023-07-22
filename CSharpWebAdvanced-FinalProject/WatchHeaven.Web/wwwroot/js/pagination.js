// Event handler for pagination links
document.addEventListener("DOMContentLoaded", function () {
    const paginationLinks = document.querySelectorAll(".pagination a");
    paginationLinks.forEach(link => {
        link.addEventListener("click", function (event) {
            event.preventDefault();
            const url = new URL(this.href);
            const currentPage = url.searchParams.get("currentPage");
            const sorting = url.searchParams.get("WatchSorting");
            const category = url.searchParams.get("Category");
            const condition = url.searchParams.get("Condition");
            const searchTerm = url.searchParams.get("SearchString");
            const newUrl = new URL(this.href);
            newUrl.searchParams.set("currentPage", currentPage);
            newUrl.searchParams.set("WatchSorting", sorting);
            newUrl.searchParams.set("Category", category);
            newUrl.searchParams.set("Condition", condition);
            newUrl.searchParams.set("SearchString", searchTerm);
            window.location.href = newUrl.href;
        });
    });
});
