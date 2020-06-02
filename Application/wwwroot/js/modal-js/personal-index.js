(function ($) {
    function Personal() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-personal").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Personal();
        self.init();
    })
}(jQuery))