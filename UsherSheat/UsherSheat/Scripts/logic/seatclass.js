/// <reference path="../typings/jquery/jquery.d.ts" />
var SeatLogic = /** @class */ (function () {
    function SeatLogic(urlParameter) {
        this.models = [];
        this.url = urlParameter;
        this.models = new Array();
    }
    /**
     * build default seats
     */
    SeatLogic.prototype.buildSeat = function () {
    };
    /**
     * check if seat is already occupied and
     * if not,  Add new seat and set it to be occupied and save it to the database
     * @param column
     * @param x
     * @param y
     */
    SeatLogic.prototype.occupiedSeat = function (column, x, y) {
        if (this.isOccupied(column, x, y) === false) {
        }
        else {
            alert("The seat is already occupied");
        }
    };
    SeatLogic.prototype.isOccupied = function (column, x, y) {
        return false;
    };
    /**
     * Refresh the dash board periodicly from web api
     */
    SeatLogic.prototype.refreshDashboard = function () {
        var _this = this;
        $.ajax({
            url: this.url,
            dataType: 'json',
            cache: false,
            success: function (result) {
            },
        }).done(function (results) {
            //parse it into models                    
            _this.models.length = 0; //clear array
            for (var i = 0; i < results.length - 1; i++) {
                var seat = new SeatDto();
                seat.column = results[i].column;
                seat.row = results[i].row;
                seat.isOccupied = results[i].isOccupied;
                seat.isDisabled = results[i].isDisabled;
                _this.models.push(seat);
            }
        });
    };
    return SeatLogic;
}());
;
//# sourceMappingURL=seatclass.js.map