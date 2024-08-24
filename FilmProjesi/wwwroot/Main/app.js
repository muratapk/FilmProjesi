$(document).ready(() => {
    // Hamburger menüye tıklama olayı
    $('#hamburger-menu').click(() => {
        // Hamburger menüye 'active' sınıfını ekler veya kaldırır
        $('#hamburger-menu').toggleClass('active')
        // Navigasyon menüsüne 'active' sınıfını ekler veya kaldırır
        $('#nav-menu').toggleClass('active')
    })


    // Kaydırma düğmeleri için özel HTML simgeleri
    let navText = ["<i class='bx bx-chevron-left'></i>", "<i class='bx bx-chevron-right'></i>"]

    // Ana kahraman kaydırıcısı (hero carousel) için Owl Carousel ayarları
    $('#hero-carousel').owlCarousel({
        items: 1, // Aynı anda gösterilecek öge sayısı
        dots: false, // Alt noktaları devre dışı bırakır
        loop: true, // Sonsuz döngü sağlar
        nav: true, // Önceki ve sonraki düğmeleri etkinleştirir
        navText: navText, // Önceki ve sonraki düğmelerin HTML içeriği
        autoplay: true, // Otomatik oynatma etkinleştirir
        autoplayHoverPause: true // Fareyle üzerine gelindiğinde otomatik oynatmayı duraklatır
    })

    // "Top Movies" kaydırıcısı için Owl Carousel ayarları
    $('#top-movies-slide').owlCarousel({
        items: 2, // Aynı anda gösterilecek başlangıç öge sayısı
        dots: false, // Alt noktaları devre dışı bırakır
        loop: true, // Sonsuz döngü sağlar
        autoplay: true, // Otomatik oynatma etkinleştirir
        autoplayHoverPause: true, // Fareyle üzerine gelindiğinde otomatik oynatmayı duraklatır
        responsive: {
            500: {
                items: 3 // Ekran genişliği 500px ve üzeri olduğunda gösterilecek öge sayısı
            },
            1280: {
                items: 4 // Ekran genişliği 1280px ve üzeri olduğunda gösterilecek öge sayısı
            },
            1600: {
                items: 6 // Ekran genişliği 1600px ve üzeri olduğunda gösterilecek öge sayısı
            }
        }
    })

    // Genel film kaydırıcıları için Owl Carousel ayarları
    $('.movies-slide').owlCarousel({
        items: 2, // Aynı anda gösterilecek başlangıç öge sayısı
        dots: false, // Alt noktaları devre dışı bırakır
        nav: true, // Önceki ve sonraki düğmeleri etkinleştirir
        navText: navText, // Önceki ve sonraki düğmelerin HTML içeriği
        margin: 15, // Ögeler arasında 15px boşluk bırakır
        responsive: {
            500: {
                items: 2 // Ekran genişliği 500px ve üzeri olduğunda gösterilecek öge sayısı
            },
            1280: {
                items: 4 // Ekran genişliği 1280px ve üzeri olduğunda gösterilecek öge sayısı
            },
            1600: {
                items: 6 // Ekran genişliği 1600px ve üzeri olduğunda gösterilecek öge sayısı
            }
        }
    })
})
