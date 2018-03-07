function seat()
{
    /** global variable **/
    var totalPeople = 0;
    var newPeople = 0;
    var foreignPeople = 0;
    var defaultRowNumber = 5;
    var extraRowCol1 = 0;
    var extraRowCol2 = 0;
    var extraRowCol3 = 0;
    var extraRowCol4 = 0;
    var extraRowCol5 = 0;

    /**
     * Function to change status of the seat (empty|seated|new people | empty)
     */
    this.seat = function (divid)
    {
        //change the element color of button divid and the value
        //state : empty->seated->newpeople->empty
        if ($(divid).text() == "O") {
            $(divid).text('X');
            $(divid).removeClass("label-success");
            $(divid).addClass("label-danger");

            totalPeople += 1;
            $(txtTotalPeople).val(totalPeople);
        }
        else if ($(divid).text() == "X") {
            $(divid).text('N');
            $(divid).removeClass("label-danger");
            $(divid).addClass("label-info");

            newPeople += 1;
            $(txtNewPeople).val(newPeople);
        }
        else if ($(divid).text() == "N") {
            $(divid).text('T');
            $(divid).removeClass("label-info");
            $(divid).addClass("label-warning");

            newPeople -= 1;
            $(txtNewPeople).val(newPeople);

            foreignPeople += 1;
            $(txtForeignPeople).val(foreignPeople);

        }
        else {
            $(divid).text('O');
            $(divid).removeClass("label-warning");
            $(divid).addClass("label-success");

            totalPeople -= 1;
            $(txtTotalPeople).val(totalPeople);

            foreignPeople -= 1;
            $(txtForeignPeople).val(foreignPeople);
        }
    }

    /*
     * Function to add seat dynamically
     */
    this.addSeat = function (tableid, bigcolumn)
    {
        var row = defaultRowNumber;
        if (bigcolumn == 1) {
            extraRowCol1 += 1;
            row += extraRowCol1;
        }
        else if (bigcolumn == 2) {
            extraRowCol2 += 1;
            row += extraRowCol2;
        }

        var x = this.buildSeat(bigcolumn, row);
        var str = " <table class='table table-stripped'><tr><td>" + x + "</td></tr></table>";

        $("#" + tableid).hide().append(str).fadeIn('slow');
    }

    /**
     * Function to build seat in one row html
     */
    this.buildSeat = function (bigcol, row)
    {
        var idstr = "tablecol" + bigcol + "row" + row + "col";

        var str = " <label id='" + idstr + "1' class='label label-success' onclick='seat(this)'>O</label> " +
            " <label id='" + idstr + "2' class='label label-success' onclick='seat(this)'>O</label>" +
            " <label id='" + idstr + "3' class='label label-success' onclick='seat(this)'>O</label>" +
            " <label id='" + idstr + "4' class='label label-success' onclick='seat(this)'>O</label>" +
            " <label id='" + idstr + "5' class='label label-success' onclick='seat(this)'>O</label>";

        return str;
    }
}