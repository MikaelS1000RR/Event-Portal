<template>
  <div class="details-wrapper">
    <vue-fontawesome icon="file" size="2" color="lightgray"></vue-fontawesome>
    <v-card
 :loading="loading"
    class="mx-auto my-12"
  outlined
  shaped
  tile
>

<div class="event-name">
<p>{{currEvent.name}}</p>
</div>

<div class="event-details">

<div class="event-info">
 <ul>
   <li>
      <v-icon
      large
      color="black"
    >
      mdi-domain
    </v-icon>
     <p>{{currEvent.location}}</p>
   </li>

   <li>
      <v-icon
      large
      color="black"
    >
      mdi-clock-time-nine-outline
    </v-icon>

    <p>{{currEvent.EndDateTime}}</p>
     
   </li>

   <li>
      <v-icon
      large
      color="black"
    >
      mdi-calendar-range
    </v-icon>

    <p></p>
   </li>

   <li>
      <v-icon
      large
      color="black"
    >
      mdi-account-circle-outline
    </v-icon>
   <p>{{hostUser.firstName}}</p>
  

   </li>

   <li>
      <v-icon
      large
      color="black"
      v-if="currEvent.access === 'private'"
    >
      mdi-lock
    </v-icon>

    <v-icon
      large
      color="black"
      v-else
    >
      mdi-lock-open
    </v-icon>

    <p>{{currEvent.access}}</p>
   </li>

   

 </ul>
</div>

<div class="event-desc">

</div>

</div>


</v-card>
  </div>
</template>

<script>
export default {

   computed: {
    currEvent() {
      
      return this.$store.state.specEvent
    },
    hostUser(){
  
       return this.$store.state.specUser
    }
  },
 async created() {
  // await this.$store.commit('setEventId',  )
    await this.$store.dispatch("fetchSpecEvent", this.$route.params.id);
    await this.$store.dispatch("fetchSpecUser", this.$store.state.specEvent.hostId)
   
  //await this.$store.commit('setUserId', this.$store.state.specEvent.hostId)
    //await this.$store.dispatch("fetchSpecUser")

    
  },
}
</script>

<style scoped>

.details-wrapper{
  width:100%;
   display: flex;
  justify-content: center;
  align-items: center;


}

.my-12{
  width:90vw;
  /*height:80vh;*/
  background-color: white;
     display: flex;
     flex-direction: column;
  justify-content: center;
  align-items: center;
}

.event-name{
  width:100%;
  height:20%;

  font-weight: bold;
  font-size:1.5vw;
  padding-left:2vw;
  padding-top:1vw;
}

.event-details{

  display: grid;
  grid-template-columns: repeat(2, 1fr);
  justify-content: center;
  align-items: center;
  width:100%;

}

ul {
    list-style-type: none;
}

ul>li{
  display: flex;
  flex-direction: row;
  padding:1.5vw;
  align-items: center;
 
}

</style>