(function ($) {
    function tblInforming() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-informing").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new tblInforming();
        self.init();
    })
}(jQuery))
