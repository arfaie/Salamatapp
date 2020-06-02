(function ($) {
    function TblContent() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-Content2").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new TblContent();
        self.init();
    })
}(jQuery))
