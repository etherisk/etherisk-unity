var getData = function(){

	var data = {
		"version": "1.0",
		"data": {
			"sampleArray": [
				"string value",
				5,
				{
					"name": "sub object"
				}
			]
		}
	}

	var returnString = JSON.stringify(data)

	SendMessage ( 'RiskAPI', 'updateData', returnString )

	// return data

}

