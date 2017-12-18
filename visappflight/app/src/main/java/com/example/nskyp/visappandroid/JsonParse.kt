package com.example.nskyp.visappandroid

import android.annotation.SuppressLint
import android.util.Log
import com.example.nskyp.visappandroid.fligt.flight
import com.example.nskyp.visappandroid.places.place
import com.google.android.gms.maps.model.LatLng
import org.json.JSONArray
import org.json.JSONObject
import java.io.*
import java.net.URL
import java.net.URLConnection
import java.sql.Array
import java.text.SimpleDateFormat
import java.util.*
import kotlin.collections.ArrayList

/**
 * Created by nskyp on 17-Dec-17.
 */
class JsonParse() {
    fun getParseJson(sName:String):List<place> {
         val listData = ArrayList<place>()
         try {
             val temp = sName.replace(" ", "%20")
             val js = URL("https://api.skypicker.com/locations/?term=" + temp)
             val jc: URLConnection = js.openConnection()
             val reader = BufferedReader(InputStreamReader(jc.getInputStream()))
             val line: String = reader.readLine()
             val jsonResponse = JSONObject(line)
             val jsonArray:JSONArray = jsonResponse.getJSONArray("locations")

             for (i in 0 until jsonArray.length()){
                val r: JSONObject = jsonArray.getJSONObject(i);
                    Log.i("r",r.toString())
                 listData.add(place(r.getString("name"),r.getString("id")))
             }

         } catch (e1: Exception) {

             e1.printStackTrace()
         }
         return listData
     }

     fun getParseJsonFlight(flightFrom: String, flightTo:String, dateFrom: String) : List<flight>{

        var listData = ArrayList<flight>()
            try {
                val locFrom:ArrayList<LatLng> = ArrayList<LatLng>()
                val locTo:ArrayList<LatLng> =ArrayList<LatLng>()

                var pomFrom:LatLng = LatLng(0.0,0.0)
                var pomTo:LatLng = LatLng(0.0,0.0)
                val temp = dateFrom.replace("/", "%2F")
                val js = URL("https://api.skypicker.com/flights?flyFrom=$flightFrom&to=$flightTo&dateFrom=$temp&limit=20&curr=CZK&sort=price")
                val jc:URLConnection = js.openConnection()
                val reader = BufferedReader(InputStreamReader(jc.getInputStream()))
                val line: String = reader.readLine()
                val jsonResponse = JSONObject(line)
                val jsonArray: JSONArray = jsonResponse.getJSONArray("data")

                for(i in 0 until jsonArray.length()){
                    val r: JSONObject = jsonArray.getJSONObject(i)
                    val loc: JSONArray = r.getJSONArray("route")

                    for (x in 0 until loc.length()){
                        val l: JSONObject = loc.getJSONObject(x)
                        if(l.getDouble("latFrom")!=l.getDouble("lngTo")){
                            pomFrom = LatLng(l.getDouble("latFrom"),l.getDouble("lngFrom"))
                            locFrom.add(pomFrom)
                            pomTo = LatLng(l.getDouble("latTo"),l.getDouble("lngTo"))
                            locTo.add(pomTo)
                       }
                    }


                    listData.add(flight(r.getString("cityFrom"),r.getString("cityTo"), r.getString("price"),r.getString("fly_duration"), getTime( r.getLong("dTime"),"dd/MM/yyyy hh:mm"),locFrom,locTo))


                }
            }catch (e1: Exception){
                e1.printStackTrace()
            }
        return  listData;
    }


    @SuppressLint("SimpleDateFormat")
    fun getTime(unixTime:Long, dateFrom:String):String{
        val date = Date(unixTime*1000L)
        val sdf = SimpleDateFormat(dateFrom)
        sdf.timeZone = TimeZone.getTimeZone("GMT+1")
        val formated: String = sdf.format(date)
        return formated
    }


}


