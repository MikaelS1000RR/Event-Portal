<template>
  <div class="myCreated-Events-container" >

<!-- :style="{backgroundImage: `url(${GeshdoT})`}" -->
     <div class="event-list" >
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>

  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";
import GeshdoT from "../assets/GeshdoT.png"

export default {

  data() {
    return {
     // GeshdoT,

    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
      
       const myEvents = this.$store.state.allEvents.filter
        (event => event.hostId === this.$store.state.account.homeAccountIdentifier);

        console.log(myEvents);

         return myEvents;
     },
     
    

    
},

async created() {
      await this.$store.dispatch('fetchEvents');
    }
 


}
</script>

<style scoped>
.event-card[data-v-aeb76366] {
    text-align: center;
    height: 75%;
    width: 20%;
    display: table-row;
    align-items: center;
    transition: transform 0.2s;
}

  /*background-image: url("../assets/GeshdoT.png"); */

</style>