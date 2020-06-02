(function ($) {
    function tbl_Institution() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-institution").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new tbl_Institution();
        self.init();
    })
}(jQuery))