﻿$(function () {
    // magical number: pixels from end where fire infinite scroll event
    let pixels = 5;

    $(".button-collapse").sideNav();

    $('.carousel').carousel({ full_width: true });
    $('.carousel-slider').slider({ full_width: true });

    let requester = {
        get(url, body, headers) {
            let promise = new Promise((resolve, reject) => {
                $.ajax({
                    url,
                    method: "GET",
                    headers,
                    contentType: 'application/json',
                    data: JSON.stringify(body),
                    success(response) {
                        resolve(response);
                    },
                    error(err) {
                        reject(err);
                    }
                });
            });

            return promise;
        }
    };

    let defaultCreateItemCallback = function (item) {
        let $wrapper = $('<div />').addClass('card');
        let $cardImageDiv = $('<div />').addClass('card-image');
        let $img = $('<img>').attr('src', item.url);
        let $titleSpan = $('< span />').addClass('card-title').val(item.title);
        let $link = $('<a />').attr('href', item.link);

        $cardImageDiv.append($img);
        $cardImageDiv.append($titleSpan);
        $cardImageDiv.append($link);

        $wrapper.append($cardImageDiv);
    };

    let addItems = function (selector, url, page, createItemCallback) {
        let $items = $(selector);
        page = page || 0;
        createItemCallback = createItemCallback || defaultCreateItemCallback;

        requester.get(url, { page: page })
            .then(data => {
                data.data.ForEach(x => {
                    let element = createItemCallback(x);

                    $items.append(element);
                });
            })
            .catch(err => console.log(err));
    };

    let infiniteScroll = function (selector, url, createItemCallback) {
        let currentPage = 0;

        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() > $(document).height() - pixels) {
                currentPage++;
                addItems(selector, url, currentPage, createItemCallback);
            }
        });
    };
});