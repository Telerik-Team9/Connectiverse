﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*Like a post*/

function likepost(postId, button) {

    let $button = $(button);
    let isLiked = $button.attr('isliked');
    let json = { postId: postId, isLiked: isLiked };
    let likesCount = $('#likesCount_' + postId);
    $.ajax({
        type: "POST",
        url: "/Post/Like",
        data: {
            'postId': postId,
            'isLiked': isLiked
        },
        success: function (data) {
            if (isLiked === 'true') {
                $button.css('color', 'powderblue');//.color = "blue";
                button.setAttribute('isliked', 'false');
            } else {
                $button.css('color', 'blue');
                button.setAttribute('isliked', 'true');
            }
            console.log(isLiked);
        }
    });
};

/*global console, document, $, jQuery */
(function ($) {
    'use strict';
    $(function () {

        // Appel du plugin
        $('.pagination').pagination({
            itemsToPaginate: ".post",
            activeClass: 'active'
        });
    });
}(jQuery));


//function likepost(postId, isLiked) {
//    let json = { postId: postId, isLiked: isLiked };
//    $.ajax({
//        type: "POST",
//        url: "https://localhost:5001/Post/Like",
//        data: JSON.stringify(json),
//        contentType: "application/json; charset=utf-8",
//        processData: "json",
//        success: function (data) {
//            console.log(data);
//            $('#likesCount_' + postId).html(data);
//            location.reload();
//        }
//    });
//};

function showComments(postId) {

    let commentBlock = $('#comments_' + postId);
    let comments = commentBlock.children();

    let attr = commentBlock.attr('data-display');

    if (typeof attr !== typeof undefined && attr !== false) {

        for (var i = 0; i < comments.length; i++) {
            comments[i].removeAttribute('hidden');
        }
        commentBlock.removeAttr('data-display');
    }
    else {
        for (var i = 0; i < comments.length; i++) {
            if (i > 2) {
                if (i !== comments.length - 1) {
                    comments[i].setAttribute('hidden', 'hidden');
                }
            }
        }
        commentBlock.attr('data-display', 'on');
    }
}


/* -----------------------------------------------
/* How to use? : Check the GitHub README
/* ----------------------------------------------- */

/* To load a config file (particles.json) you need to host this demo (MAMP/WAMP/local)... */

particlesJS.load('particles-js', 'particles.json', function () {
    console.log('particles.js loaded - callback');
});


/* Otherwise just put the config content (json): */
particlesJS('particles-js',
    {
        "particles": {
            "number": {
                "value": 100,
                "density": {
                    "enable": true,
                    "value_area": 800
                }
            },
            "color": {
                "value": "#ffffff"
            },
            "shape": {
                "type": "star",
                "stroke": {
                    "width": 0,
                    "color": "#000000"
                },
                "polygon": {
                    "nb_sides": 5
                },
                "image": {
                    "src": "img/kiro.png",
                    "width": 100,
                    "height": 100
                }
            },
            "opacity": {
                "value": 0.5,
                "random": false,
                "anim": {
                    "enable": false,
                    "speed": 1,
                    "opacity_min": 0.1,
                    "sync": false
                }
            },
            "size": {
                "value": 5,
                "random": true,
                "anim": {
                    "enable": true,
                    "speed": 20,
                    "size_min": 0.1,
                    "sync": false
                }
            },
            "line_linked": {
                "enable": true,
                "distance": 150,
                "color": "#ffffff",
                "opacity": 0.4,
                "width": 1
            },
            "move": {
                "enable": true,
                "speed": 2,
                "direction": "none",
                "random": false,
                "straight": false,
                "out_mode": "out",
                "attract": {
                    "enable": false,
                    "rotateX": 600,
                    "rotateY": 1200
                }
            }
        },
        "interactivity": {
            "detect_on": "canvas",
            "events": {
                "onhover": {
                    "enable": true,
                    "mode": "grab"
                },
                "onclick": {
                    "enable": true,
                    "mode": "push"
                },
                "resize": true
            },
            "modes": {
                "grab": {
                    "distance": 400,
                    "line_linked": {
                        "opacity": 0.7
                    }
                },
                "bubble": {
                    "distance": 400,
                    "size": 40,
                    "duration": 2,
                    "opacity": 8,
                    "speed": 3
                },
                "repulse": {
                    "distance": 200
                },
                "push": {
                    "particles_nb": 4
                },
                "remove": {
                    "particles_nb": 2
                }
            }
        },
        "retina_detect": true,
        "config_demo": {
            "hide_card": false,
            "background_color": "#b61924",
            "background_image": ".../img/bg-galaxy.jpg",
            "background_position": "50% 50%",
            "background_repeat": "no-repeat",
            "background_size": "cover"
        }
    }

);
