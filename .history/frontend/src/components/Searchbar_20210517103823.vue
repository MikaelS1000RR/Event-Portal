<template>
    <div class="searchbar">
     <input type="text" placeholder="Search events..."  v-model="searchQuery" @change="setEvents"/>
</div>

</template>

<script>
export default {
  
  data() {
    return {

      searchQuery: ""
      
      }

  },

methods: {
    setEvents(){
      
      let myEvents = this.$store.state.allEvents.filter
      (event => event.hostId === this.$store.state.account.homeAccountIdentifier);

      console.log(myEvents);

      
        
       
          this.$store.commit("setFilteredEventsByLetter", myEvents);
     },
    
},

async created() {
      await this.$store.dispatch('fetchEvents');

    }
}
</script>

<style>

</style>