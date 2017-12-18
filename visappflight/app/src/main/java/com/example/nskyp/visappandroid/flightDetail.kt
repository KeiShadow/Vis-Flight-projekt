package com.example.nskyp.visappandroid

import android.annotation.SuppressLint
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.os.Parcel
import android.os.Parcelable
import android.util.Log
import android.widget.TextView
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.model.MarkerOptions
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.model.Polyline
import com.google.android.gms.maps.model.PolylineOptions
import java.util.ArrayList


class flightDetail : AppCompatActivity(), OnMapReadyCallback, GoogleMap.OnPolylineClickListener {

    lateinit var cityFrom: TextView
    lateinit var cityTo: TextView
    lateinit var price: TextView
    lateinit var dur: TextView
    lateinit var dTime:TextView


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_flight_detail)

        // Get the SupportMapFragment and request notification
        // when the map is ready to be used.
        val mapFragment = supportFragmentManager
                .findFragmentById(R.id.map) as SupportMapFragment
        mapFragment.getMapAsync(this)

        cityFrom = findViewById<TextView>(R.id.tv_cityFrom)
        cityTo = findViewById<TextView>(R.id.tv_cityTo)
        price = findViewById<TextView>(R.id.tv_Cena)
        dur = findViewById<TextView>(R.id.tv_Durration)
        dTime = findViewById<TextView>(R.id.tv_dTime)


        cityFrom.text= "Odkud letím?: "+intent.getStringExtra("CityFrom")
        cityTo.text= "Kam letím?: "+intent.getStringExtra("CityTo")
        price.text= intent.getStringExtra("price")+" Kč"
        dur.text= "Celková doba letu: "+intent.getStringExtra("TotalDuration")
        dTime.text= "Kdy letím?: "+intent.getStringExtra("DepFrom")







    }

    override fun onMapReady(googleMap: GoogleMap) {

        val locFrom:ArrayList<LatLng> = intent.getParcelableArrayListExtra("LocationsFrom")
        Log.e("locFrom:",locFrom.size.toString())
        val locTo:ArrayList<LatLng> = intent.getParcelableArrayListExtra("LocationsTo")
        Log.e("locTo:",locFrom.size.toString())
       var newLocBoth = ArrayList<LatLng>(locFrom.size)

        locFrom.union(locTo)
        for(i in 0 until locFrom.size){
            // newLocBoth[j] = locTo[j]
            for( j in 1 until  locTo.size) {
                newLocBoth.add(i,locFrom[i])
                newLocBoth.add(j,locTo[j])
            }
        }
        googleMap.addPolyline(PolylineOptions().clickable(true).addAll(newLocBoth))



        val sydney:LatLng = LatLng(-33.852, 151.211);
        //googleMap.addMarker( MarkerOptions().position(sydney).title("Mark in the sydney"));
        googleMap.moveCamera(CameraUpdateFactory.newLatLng(sydney))
        googleMap.setOnPolylineClickListener(this)
    }

    override fun onPolylineClick(p0: Polyline?) {
        TODO("not implemented") //To change body of created functions use File | Settings | File Templates.
    }

}







