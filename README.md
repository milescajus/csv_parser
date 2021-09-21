# C\# CSV Parser

Takes any valid two-row (header and data) CSV file using commas `,` as the separator and double quotes `"` as the escape character as per [RFC 4180](https://www.ietf.org/rfc/rfc4180.txt) and calculates a sum and mean over the data set, outputting to `results.csv` with overwriting.

## Example Input

<table>
	<tr>
		<td>January</td>
		<td>February</td>
		<td>March</td>
	</tr>
	<tr>
		<td>$50,000.23</td>
		<td>$400.23</td>
		<td>$7,034.00</td>
	</tr>
</table>

## Example Output

<table>
	<tr>
		<td>Sum</td>
		<td>Average</td>
	</tr>
	<tr>
		<td>Value</td>
		<td>Value</td>
	</tr>
</table>
