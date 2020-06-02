(function ($) {
    function tbl_CommentOrgan() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-organ").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new tbl_CommentOrgan();
        self.init();
    })
}(jQuery))
