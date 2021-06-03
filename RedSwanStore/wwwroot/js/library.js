﻿let filterAndSort = {
    sortId: "alphabetically",
    filterId: "all"
}

document.querySelectorAll('.library-sort-btn').forEach(btn => {
    btn.addEventListener('click', function() {
        filterAndSort.sortId = btn.getAttribute('data-controller-arg');
        sendDataToServerByAjax();
    })
});

document.querySelectorAll('.library-filter-btn').forEach((btn) => {
    btn.addEventListener('click', function() {
       filterAndSort.filterId = btn.getAttribute('data-controller-arg');
       sendDataToServerByAjax();
    });
});


let sendDataToServerByAjax = function (onSuccessCallback) {
    $.ajax({
        type: 'post',
        url: '/library',
        data: {
            sortId: filterAndSort.sortId,
            filterId: filterAndSort.filterId
        },
        dataType: 'html',
        error: (message) => {
            alert(message.toString());
        },
        success: (html) => onSuccessCallback(html)
    });
}

let onSuccess = (html) => {
    let gamesCardsBlock = $('#games-cards');

    gamesCardsBlock.empty();
    gamesCardsBlock.append(html);
    
    let game_card = document.querySelector(".game-card");
    let message = document.querySelector(".section_empty");


    if (!game_card)
        message.classList.remove("hidden");
    else
        message.classList.add("hidden");
}