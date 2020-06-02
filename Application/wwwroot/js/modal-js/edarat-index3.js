(function ($) {
    function TblEdarat() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-edarat3").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new TblEdarat();
        self.init();
    })
}(jQuery))
