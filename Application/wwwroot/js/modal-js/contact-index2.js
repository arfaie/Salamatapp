(function ($) {
    function tbl_Contact() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-contact2").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new tbl_Contact();
        self.init();
    })
}(jQuery))