(function ($) {
    function NazarSanji2() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-nazarsanji").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new NazarSanji2();
        self.init();
    })
}(jQuery))
