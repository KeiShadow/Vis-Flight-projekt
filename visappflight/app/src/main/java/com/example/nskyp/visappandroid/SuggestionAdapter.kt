package com.example.nskyp.visappandroid

import java.util.ArrayList;

import android.app.Activity;
import android.content.res.Resources
import android.os.Parcel
import android.os.Parcelable

import android.widget.ArrayAdapter;
import android.widget.Filter;
import android.widget.Filterable

import com.example.nskyp.visappandroid.places.place


/**
 * Created by nskyp on 17-Dec-17.
 */
open class SuggestionAdapter(context:Activity, sName:String) : ArrayAdapter<String>(context,android.R.layout.simple_dropdown_item_1line) {

    protected val TAG:String = "SuggestionAdapter"
     var suggestionList: ArrayList<String> = ArrayList()



    override fun getCount(): Int {
        return suggestionList.size
    }

    override fun getItem(position: Int): String {
        return suggestionList[position]
    }

    override fun getFilter(): Filter {
        return object :Filter(){


            override fun performFiltering(charSequence: CharSequence?): FilterResults {
                val filterResults = FilterResults()
                val jp = JsonParse()
                if(charSequence !=null){
                    val new_suggestion: List<place> = jp.getParseJson(charSequence.toString())
                    suggestionList.clear()

                    for (i in 0 until new_suggestion.size){
                        suggestionList.add(new_suggestion[i].getName())

                    }
                    filterResults.values = suggestionList
                    filterResults.count = suggestionList.size

                }
                return filterResults

            }
            override fun publishResults(p0: CharSequence?, result: FilterResults?) {
                if(result !=null && result.count>0 ){
                    notifyDataSetChanged()

                }else{
                    notifyDataSetInvalidated()
                }
            }
        }
    }
}
