package com.example.nskyp.visappandroid

import android.annotation.SuppressLint
import android.content.Context
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.TextView
import com.example.nskyp.visappandroid.fligt.flight
import org.w3c.dom.Text

/**
 * Created by nskyp on 17-Dec-17.
 */
class myCustomAdapter(context:Context,
                      flightList:List<flight>): BaseAdapter() {

    private  var flightList: List<flight> = flightList
    var mContext:Context
    init{
        mContext = context
    }

    override fun getItem(p0: Int): Any {
        return flightList[p0]
    }

    override fun getItemId(possition:  Int): Long {
        return possition.toLong()
    }

    override fun getCount(): Int {
        return flightList.size
    }

    @SuppressLint("ViewHolder", "SetTextI18n")
    override fun getView(possition: Int, convertView: View?, viewGroup: ViewGroup?): View {
        var v:View = View.inflate(mContext,R.layout.row,null)
        val twcityFromTo = v.findViewById<TextView>(R.id.twcityFromTo)
        val price = v.findViewById<TextView>(R.id.tv_price)
        val duration = v.findViewById<TextView>(R.id.tv_Duration)
        val date = v.findViewById<TextView>(R.id.tv_Date)

        twcityFromTo.text = flightList[possition].flightFrom + " - " + flightList[possition].flightTo
        price.text = flightList[possition].price
        duration.text = "Doba cestování: "+flightList[possition].duration
        date.text = "- "+flightList[possition].depFrom


        return  v;





    }
}