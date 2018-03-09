/// <reference path="../typings/jquery/jquery.d.ts" />
var SeatLogic = /** @class */ (function () {
    function SeatLogic(urlParameter) {
        this.models = [];
        /*
         * Url of the web api
         */
        this.url = 'http://localhost:54392/api/seat/';
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
     * @param column : which column that has been occupied
     * @param x : x coordinate
     * @param y : y coordinate
     */
    SeatLogic.prototype.occupySeat = function (column, x, y) {
        if (this.isOccupied(column, x, y) === false) {
        }
        else {
            alert("The seat is already occupied");
        }
    };
    /**
     * Check if seat is already occupied
     * @param column
     * @param x
     * @param y
     */
    SeatLogic.prototype.isOccupied = function (column, x, y) {
        var seat = this.getSeat(column, x, y);
        if (seat) {
            throw new TypeError("Seat is not exist");
        }
        if (seat.isOccupied) {
            return true;
        }
        return false;
    };
    SeatLogic.prototype.getSeat = function (column, x, y) {
        this.models.forEach(function (value) {
            if (value.column === column && value.x === x && value.y === y) {
                return value;
            }
        });
        return null;
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
                seat.x = results[i].Position.x;
                seat.y = results[i].Position.y;
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