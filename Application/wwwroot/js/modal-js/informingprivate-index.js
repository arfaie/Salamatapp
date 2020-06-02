(function ($) {
    function informingprivate() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-informingprivate").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new informingprivate();
        self.init();
    })
}(jQuery))