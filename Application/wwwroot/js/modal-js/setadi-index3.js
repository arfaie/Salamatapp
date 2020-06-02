(function ($) {
    function Setadi() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-setadi3").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Setadi();
        self.init();
    })
}(jQuery))