(function ($) {
    function Informing() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-informing2").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Informing();
        self.init();
    })
}(jQuery))

