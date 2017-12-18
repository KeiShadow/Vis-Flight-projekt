package com.example.nskyp.visappandroid

import android.annotation.SuppressLint
import android.app.DatePickerDialog
import android.app.Dialog
import android.app.DialogFragment
import android.content.Intent
import android.os.Bundle
import android.support.v7.app.AppCompatActivity

import java.util.*
import android.os.StrictMode
import android.util.Log
import android.view.View
import android.widget.*

import android.widget.ArrayAdapter
import com.example.nskyp.visappandroid.fligt.flight


class MainActivity : AppCompatActivity() {
    var TAG:String = "MainActivity"


    lateinit var dateDep: EditText
    lateinit var dateRet: EditText
    lateinit  var myCalendar: Calendar
    lateinit var  flightList:List<flight>


    @SuppressLint("ShowToast")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        val policy = StrictMode.ThreadPolicy.Builder().permitAll().build()

        StrictMode.setThreadPolicy(policy)

        dateDep = findViewById(R.id.dateDep)
        dateRet = findViewById(R.id.dateRet)

        myCalendar = Calendar.getInstance()

        dateDep.setOnClickListener {
            var fragment: DialogFragment = DatePickerFragment()
            fragment.show( fragmentManager,"Date From")
        }


        val acflightFrom = findViewById<AutoCompleteTextView>(R.id.flightFrom)
        acflightFrom.setAdapter(SuggestionAdapter(this, acflightFrom.text.toString()))

        val acflightTo = findViewById<AutoCompleteTextView>(R.id.flightTo)
        acflightTo.setAdapter(SuggestionAdapter(this, acflightFrom.text.toString()))

        val btFindFlight = findViewById<Button>(R.id.btFind)



        var listView = findViewById<ListView>(R.id.listView)

        btFindFlight.setOnClickListener {
              flightList = JsonParse().getParseJsonFlight(acflightFrom.text.toString(),acflightTo.text.toString(),dateDep.text.toString())

             listView.adapter = myCustomAdapter(this, flightList)
        }


        listView.setOnItemClickListener{
            parent: AdapterView<*>?, view: View?, possition: Int, id: Long ->
            Toast.makeText(this,"Kliknul si na: "+flightList[possition].flightFrom,Toast.LENGTH_LONG).show()
           val intent = Intent(this, flightDetail::class.java)
                intent.putExtra("CityFrom",flightList[possition].getflighFrom())
                intent.putExtra("CityTo",flightList[possition].getflightTO())
                intent.putExtra("TotalDuration",flightList[possition].getduration())
                intent.putExtra("DepFrom", flightList[possition].depFrom())
                intent.putExtra("price",flightList[possition].price)
                intent.putParcelableArrayListExtra("LocationsFrom",flightList[possition].getLocListFrom())
            intent.putParcelableArrayListExtra("LocationsTo",flightList[possition].getLocListTo())
            //Log.i("Loc:",flightList[possition].getLocList().toString())
            startActivity(intent)
        }

    }


}
open class DatePickerFragment : DialogFragment(),DatePickerDialog.OnDateSetListener{

    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog? {

        val c:Calendar = Calendar.getInstance()
         var year = c.get(Calendar.YEAR)
        var month = c.get(Calendar.MONTH)
        var day = c.get(Calendar.DAY_OF_MONTH)
            var dialog:DatePickerDialog =DatePickerDialog(activity,this,year,month,day)
        return dialog
    }

    @SuppressLint("SetTextI18n")
    override fun onDateSet(p0: DatePicker?, year: Int, month:  Int, day: Int) {
        val dateDep: EditText = activity.findViewById(R.id.dateDep)
        dateDep.setText(day.toString()+"/"+(month+1)+"/"+year.toString())
    }

}


