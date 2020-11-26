/*global console, document, $, jQuery */
(function ($) {
    'use strict';

    //    $(document).ready(function () {

    $.fn.pagination = function (options) {
        //        alert('prout');
        var paginationContainer = this,
            itemsPerPage,
            itemsToPaginate,
            defaults,
            settings,
            i,
            numberOfPaginationLinks;

        defaults = {
            itemsPerPage: 5
        };

        settings = {};

        $.extend(settings, defaults, options);

        itemsPerPage = settings.itemsPerPage;

        itemsToPaginate = $(settings.itemsToPaginate);
        numberOfPaginationLinks = Math.ceil((itemsToPaginate.length / itemsPerPage));

        // Creation of list in the targeted div
        $('<ul></ul>').prependTo(paginationContainer);

        // Loop that create li
        for (i = 0; i < numberOfPaginationLinks; i += 1) {
            paginationContainer.find('ul').append('<li>' + (i + 1) + '</li>');
        }

        itemsToPaginate.filter(':gt(' + (itemsPerPage - 1) + ')').hide();

        paginationContainer.find('ul li').on('click', function () {

            var itemsToHide,
                linkNumber,
                itemsToShow,
                $this = $(this);

            $this.addClass(settings.activeClass);
            $this.siblings().removeClass(settings.activeClass);
            
            linkNumber = $this.text();

            itemsToHide = itemsToPaginate.filter(':lt(' + ((linkNumber - 1) * itemsPerPage) + ')');

            $.merge(itemsToHide, itemsToPaginate.filter(':gt(' + ((linkNumber * itemsPerPage) - 1) + ')'));

            itemsToHide.hide();

            itemsToShow = itemsToPaginate.not(itemsToHide);
            itemsToShow.show();

        });
    };
    //    });

}(jQuery));