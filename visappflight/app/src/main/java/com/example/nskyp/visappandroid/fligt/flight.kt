package com.example.nskyp.visappandroid.fligt

import com.google.android.gms.maps.model.LatLng

/**
 * Created by nskyp on 17-Dec-17.
 */
class flight(var flightFrom:String,
             var flightTo:String,
             var price:String,
             var duration:String,
             var depFrom:String,
             var loclistFrom: ArrayList<LatLng>,
             var loclistTo: ArrayList<LatLng>) {


    fun getflighFrom(): String {
        return this.flightFrom
    }

    fun getflightTO():String{
        return this.flightTo
    }
    /*fun getdateFrom():String{
        return this.dateFrom
    }*/

    fun getprice():String{
        return this.price
    }

    fun getduration():String{
        return this.duration
    }

    fun depFrom():String{
        return this.depFrom
    }
    fun getLocListFrom():ArrayList<LatLng>{
        return this.loclistFrom
    }
    fun getLocListTo():ArrayList<LatLng>{
        return this.loclistTo
    }
}