window.initSplideGalleries = () => {
    if (document.querySelector('#main-carousel')) {
        var main = new Splide('#main-carousel', {
            type: 'fade',
            rewind: true,
            pagination: false,
            arrows: false,
        });
        main.mount();
    }

    if (document.querySelector('#thumbnail-carousel')) {
        var thumbs = new Splide('#thumbnail-carousel', {
            fixedWidth: 100,
            fixedHeight: 64,
            isNavigation: true,
            gap: 10,
            rewind: true,
            pagination: false,
        });
        thumbs.mount();
    }
}
