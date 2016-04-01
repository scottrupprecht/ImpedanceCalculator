var HomeIndex = function (userConfig) {
    var defaults = {
        urls: {
            insertSpeakerUrl: ""
        }
    };

    $.ajaxSetup({ cache: false });
    var config = $.extend(true, {}, defaults, userConfig);

    var insertSpeaker = function (brand, model, impedance) {
        console.log({ model: model, brand: brand, impedance: impedance });
        $.ajax({
            type: "POST",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            url: config.urls.insertSpeakerUrl,
            data: { model: model, brand: brand, impedance: impedance },
            success: function (result) {
                console.log(result);
            }
        });
    }

    var init = function () {
        $("#txt-num-speaker").on("change", function () {
            var numSpeakers = parseInt($(this).val());
            console.log(numSpeakers);
            if (isNaN(numSpeakers)) {
                alert("Invalid");
                return;
            }
            var speakerInputs = [];
            for (var i = 0; i < numSpeakers; i++) {
                speakerInputs.push('<label for="txt-speaker-' + (i + 1) + '">Speaker ' + (i + 1) + ': </label><input id="txt-speaker-' + (i + 1) + '" class="form-control txt-speaker" ' +
				    'data-speaker-num="' + (i + 1) + '" min="2" step="1" />');
            }
            $("#speaker-container").html("<hr/>" + speakerInputs.join(""));
            $("#btn-calculate").removeClass("hidden");
        });

        $("#btn-calculate").on("click", function () {
            displayOutput(calculate());
        });

        $("#btn-speaker-impedance").on("click", function () {
            var brand = $("#txt-speaker-brand").val();
            var model = $("#txt-speaker-model").val();
            var impedance = $("#txt-speaker-impedance").val();
            insertSpeaker(brand, model, impedance);
        });

        $("body").on("keydown", ".txt-speaker", function (event) {
            if (event.which !== 13)
                return;
            var speakerNum = parseInt($(this).data("speaker-num"));
            var nextInput = $("#txt-speaker-" + (speakerNum + 1));
            if (nextInput.length) {
                nextInput.focus();
            } else {
                displayOutput(calculate());
            }
        });
    }

    function seriesImpedance(impedanceLevels) {
        var serialImpedance = 0;
        for (var i = 0; i < impedanceLevels.length; i++) {
            serialImpedance += impedanceLevels[i];
        }
        return serialImpedance;
    }

    function parallelImpedance(impedanceLevels) {
        var impedances = 0;
        var j = 0;
        for (var i = 0; i < impedanceLevels.length; i++) {
            impedances += impedanceLevels[i];
            j++;
        }
        return impedances / j;
    }

    function multImpedance(impedanceLevels) {
        var impedance = 0;
        for (var i = 0; i < impedanceLevels.length; i++) {
            impedance += (1 / impedanceLevels[i]);
        }
        var diffParallelImpedance = 1 / impedance;
        return diffParallelImpedance;
    }

    function areEqual(intArray) {
        if (!intArray.length || intArray === 1) {
            return true;
        }
        var first = intArray[0];
        for (var i = 1; i < intArray.length; i++) {
            if (first !== intArray[i - 1]) {
                return false;
            }
        }
        return true;
    }

    function displayOutput(output) {
        if (output !== -1) {
            $("#display").text(output.toFixed(2));
        }
    }

    function calculate() {
        var impedanceLevels = [];
        $(".txt-speaker").each(function () {
            var impedance = parseInt($(this).val());
            var speakerNum = parseInt($(this).data("speaker-num"));
            if (isNaN(impedance)) {
                alert("Invalid Entry. Impedance must be an integer. Check speaker number " + speakerNum);
                return;
            }
            impedanceLevels.push(impedance);
        });
        if ($("#rad-series").is(":checked")) {
            return (seriesImpedance(impedanceLevels));
        } else {
            if (areEqual(impedanceLevels)) {
                return (parallelImpedance(impedanceLevels));
            } else {
                return (multImpedance(impedanceLevels));
            }
        }
    }
    return {
        init: init
    };
};