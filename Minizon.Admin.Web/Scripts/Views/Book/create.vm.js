/// <reference path="../../jquery-1.8.3.intellisense.js" />
/// <reference path="../../knockout-2.2.0.debug.js" />

var App = App || {};

$(function (App, $, ko) {
    "use strict";

    App.catalogService = {
        createBook: function (book) {
            $.ajax({
                url: '/api/catalog',
                type: 'post',
                dataType: 'json',
                contentType: 'application/json',
                data: book,
                success: function (response) {
                    console.log(response);
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
    };

    App.createBookViewModel = function() {
        var isbn = ko.observable(),
            name = ko.observable(),
            author = ko.observable(),
            suggestedPrice = ko.observable(),
            ourPrice = ko.observable(),
            getCatalogPart = function() {
                return {
                    name: name(),
                    author: author(),
                    isbn: isbn(),
                    suggestedPrice: suggestedPrice()
                };
            },
            getPricingPart = function() {
                return {
                    isbn: isbn(),
                    ourPrice: ourPrice()
                };
            },
            post = function () {
                App.catalogService.createBook(ko.toJSON(getCatalogPart()));
            };
            
        return {
            isbn: isbn,
            name: name,
            author: author,
            suggestedPrice: suggestedPrice,
            ourPrice: ourPrice,
            post: post
        };
    }();

    ko.applyBindings(App.createBookViewModel);
}(App, jQuery, ko));