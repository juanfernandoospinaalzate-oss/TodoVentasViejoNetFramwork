/* --|INICIALIZADOR DE DROPDOWNS|-- */
$('.ui.dropdown')
  .dropdown();

  $('#d-boton2')
    .dropdown();

/* --|SETTINGS LIBRARIA DE CARRUSEL RESPONSIVE LIGHTSLIDER|-- */
$(document).ready(function () {
    $('#t-carruselrebajas').lightSlider({
      item: 4,
      loop: false,
      slideMove: 4,
      easing: 'cubic-bezier(0.25, 0, 0.25, 1)',
      speed: 600,
      auto: false,
      controls: true,
      enableTouch: true,
      enableDrag: true,
      responsive: [
        {
          breakpoint: 850,
          settings: {
            item: 2,
            slideMove: 2,
            slideMargin: 6,
            auto: false,
            controls: true,
            enableTouch: true,
            enableDrag: true
          }
        },
        {
          breakpoint: 480,
          settings: {
            item: 1,
            slideMove: 1,
            auto: false,
            controls: true,
            enableTouch: true,
            enableDrag: true
          }
        }
      ]
    });
  });

/* --|INICIALIZADOR DE MENU POPUPS|-- */
$('#d-boton1')
  .popup({
    popup: $('#d-menupopup'),
    on: 'click',
    position: 'bottom left',
    distanceAway: 11,
    setFluidWidth: 50,
    delay: {
      show: 300,
      hide: 300
    }
  });

$('#m-botonenu')
    .popup({
      popup: $('#m-menupopup'),
      on: 'click',
      position: 'bottom left',
      distanceAway: 11,
      setFluidWidth: 50,
      delay: {
        show: 300,
        hide: 300
      }
    });

/* --|INICIALIZADOR DIMMER DE IMAGENES NO CARRUSEL|-- */
for (i = 1; i < 5; i++) {
  $('#paso' + i)
  .dimmer({
    on: 'click'
  });
}

/* --|INICIALIZADOR ACORDEON DE DATOS CONTACTO EN FOOTER|-- */
$('.ui.accordion')
  .accordion();

/* --|INICIALIZADOR EMBED VIDEO BANNER|-- */
$('.ui.embed')
  .embed();

/* --|CAMBIO DE CLASE EN PANTALLAS MENORES A 768 DE LA CAJA DE PRODUCTOS LISTA Y CAJA|-- */
/*
for (i = 0 ; i < 1 ; i++) {
  var clase = "";
  if (i = 0) {
    clase = "#t-productoscaja";
  }
  else {
      clase="#t-productoslista";
  }

  if ($(window).width() < 992) {
    $(clase)
    .removeClass('twelve wide column')
    .addClass('sixteen wide column');
  }
}
*/
$(window).load(function () { 
    if ($(window).width() <= 992) {
        $('#t-productoscaja')
        .removeClass('twelve wide column')
        .addClass('sixteen wide column');
    }

    if ($(window).width() >= 993) {
        $('#t-productoscaja')
        .removeClass('sixteen wide column')
        .addClass('twelve wide column');
    }

    if ($(window).width() <= 992) {
        $('#t-productoslista')
        .removeClass('twelve wide column')
        .addClass('sixteen wide column');
    }

    if ($(window).width() >= 993) {
        $('#t-productoslista')
        .removeClass('sixteen wide column')
        .addClass('twelve wide column');
    }

    if ($(window).width() <= 992) {
        $('#d-menufiltro')
        .removeClass('twelve wide column')
        .addClass('sixteen wide column');
    }

    if ($(window).width() >= 993) {
        $('#t-productoscaja')
        .removeClass('sixteen wide column')
        .addClass('twelve wide column');
    }

    if ($(document).width() <= 992) {
        $('#d-menufiltro')
        .removeClass('ui four wide column')
        .addClass('d-menufiltroesconder');
    }

    if ($(document).width() >= 993) {
        $('#d-menufiltro')
        .removeClass('d-menufiltroesconder')
        .addClass('ui four wide column');
    }
});

$(window).resize(function () {
    if ($(window).width() <= 992) {
        $('#t-productoscaja')
        .removeClass('twelve wide column')
        .addClass('sixteen wide column');
    }

    if ($(window).width() >= 993) {
        $('#t-productoscaja')
        .removeClass('sixteen wide column')
        .addClass('twelve wide column');
    }

    if ($(window).width() <= 992) {
        $('#t-productoslista')
        .removeClass('twelve wide column')
        .addClass('sixteen wide column');
    }

    if ($(window).width() >= 993) {
        $('#t-productoslista')
        .removeClass('sixteen wide column')
        .addClass('twelve wide column');
    }

    if ($(window).width() <= 992) {
        $('#d-menufiltro')
        .removeClass('twelve wide column')
        .addClass('sixteen wide column');
    }

    if ($(window).width() >= 993) {
        $('#t-productoscaja')
        .removeClass('sixteen wide column')
        .addClass('twelve wide column');
    }

    if ($(document).width() <= 992) {
        $('#d-menufiltro')
        .removeClass('ui four wide column')
        .addClass('d-menufiltroesconder');
    }

    if ($(document).width() >= 993) {
        $('#d-menufiltro')
        .removeClass('d-menufiltroesconder')
        .addClass('ui four wide column');
    }
});







/* --|INICIALIZADOR PGWSLIDER PARA LA GALERIA DE IMAGENES DE DETALLEPRODUCTO|-- */
$(document).ready(function() {
    $('.pgwSlider').pgwSlider({
      listPosition: 'left',
      autoSlide: false,
      touchControls: 'true'
    });
});

/* --|INICIALIZADOR JQUERYZOOM PARA EL ZOOM PARA LAS FOTOS DE LA GALERIA DE IMAGENES DE DETALLEPRODUCTO|-- */
$(document).ready(function(){
  $('a.photozoom1').zoom({url:'files/images/productos/buzo01.jpg'});
});


/* --|INICIALIZADOR SEMANTIC-UI RATINGS DE LOS PRODUCTOS EN DETALLE PRODUCTOS|-- */
$('.ui.rating')
  .rating({
    initialRating: 3,
    maxRating: 5
  })
;




('.ui.sticky')
  .sticky({
    context: '#context'
  })
;

/* --|INICIALIZADOR SEMANTIC-UI TABULADORES DE PRODUCTOS DESCRIPCIÓN, ESPECIFICACIONES, COMENTARIOS|-- */
$('.menu .item')
  .tab()
;