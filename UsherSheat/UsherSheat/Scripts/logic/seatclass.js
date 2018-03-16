/// <reference path="../typings/jquery/jquery.d.ts" />
var SeatLogic = /** @class */ (function () {
    function SeatLogic(urlParameter) {
        this.models = [];
        /*
         * Default constant value
         */
        this.defaultColumnConst = 5;
        this.defaultRowConst = 5;
        this.defaultTotalSeatsPerRow = 4;
        /*
         * Default Url of the web api
         */
        this.url = 'http://localhost:54392/api/seat/';
        this.url = urlParameter;
        this.models = new Array();
    }
    /**
     * Build Seat dynamically Html
     */
    SeatLogic.prototype.buildSeatsHtml = function () {
        var htmlResult = "";
        htmlResult += "<table class='table table-stripped'>";
        // iterate each rows
        for (var row = 0; row < this.defaultRowConst - 1; row++) {
            htmlResult += "<tr>";
            //iterate each rows
            for (var column = 0; column < this.defaultColumnConst; column++) {
                htmlResult += "<td>";
                var seats = this.buildSeatRowUi(column, row, this.defaultTotalSeatsPerRow);
                htmlResult += seats;
                htmlResult += "</td>";
            }
            htmlResult += "</tr>";
        }
        return htmlResult;
    };
    /**
     * Build seat per row in UI
     * @param column which column that we build
     * @param row which row
     * @param totalSeats total seats per row
     */
    SeatLogic.prototype.buildSeatRowUi = function (column, row, totalSeats) {
        var seats = "";
        for (var i = 0; i < this.defaultTotalSeatsPerRow; i++) {
            seats += "<td>";
            seats += this.buildSeatUi(column, i, row);
            seats += "</td>";
        }
        var str = "<table class='table table-stripped'><tr>" + seats + "</tr></table>";
        return str;
    };
    /**
     * Build one single seat UI and push the seat into model
     * @param column
     * @param x
     * @param y
     */
    SeatLogic.prototype.buildSeatUi = function (column, x, y) {
        var seat = new SeatDto();
        seat.column = column;
        seat.x = x;
        seat.y = y;
        this.models.push(seat);
        var idstr = "column_" + column + "_" + x + "_" + y;
        var str = " <label id='" + idstr + "' class='label label-success' " +
            " onclick=_service.occupySeatUi('" + idstr + "')>X</label> ";
        return str;
    };
    SeatLogic.prototype.occupySeatUi = function (htmlSeatId) {
        //parse htmlseatid added "" to make sure the htmlseatid  are string
        var rawhtmls = ("" + htmlSeatId).split('column_', 2);
        //parse again the lastelement
        var rawseats = ("" + rawhtmls[1]).split('_', 3);
        var column = Number("" + rawseats[0]);
        var x = Number("" + rawseats[1]);
        var y = Number("" + rawseats[2]);
        //typescript does not realy work with jquery therefore, i need to use document.getelementbyid
        if (this.occupySeat(column, x, y)) {
            document.getElementById(htmlSeatId).innerText = "O";
            document.getElementById(htmlSeatId).classList.remove("label-success");
            document.getElementById(htmlSeatId).classList.add("label-danger");
        }
        else {
            document.getElementById(htmlSeatId).innerText = "X";
            document.getElementById(htmlSeatId).classList.remove("label-danger");
            document.getElementById(htmlSeatId).classList.add("label-success");
        }
    };
    /**
     * check if seat is already occupied and
     * if not,  Add new seat and set it to be occupied and save it to the database
     * @param column : which column that has been occupied
     * @param x : x coordinate
     * @param y : y coordinate
     */
    SeatLogic.prototype.occupySeat = function (column, x, y) {
        for (var i = 0; i < this.models.length; i++) {
            if (this.models[i].column === column && this.models[i].x === x && this.models[i].y === y) {
                if (this.models[i].isOccupied === false) {
                    this.models[i].isOccupied = true;
                    return true;
                }
                else {
                    this.models[i].isOccupied = false;
                    return false;
                }
            }
        }
        return true;
    };
    /**
     * Check if seat is already occupied
     * @param column
     * @param x
     * @param y
     */
    SeatLogic.prototype.isOccupied = function (column, x, y) {
        var seat = this.getSeat(column, x, y);
        if (seat == null) {
            throw new TypeError("Seat is not exist");
        }
        if (seat.isOccupied) {
            return true;
        }
        return false;
    };
    SeatLogic.prototype.getSeat = function (column, x, y) {
        for (var i = 0; i < this.models.length; i++) {
            if (this.models[i].column === column && this.models[i].x === x && this.models[i].y === y) {
                return this.models[i];
            }
        }
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