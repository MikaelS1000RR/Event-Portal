<template>
    <div class="searchbar">
     <input type="text" placeholder="Search events..."  v-model="searchQuery"/>
</div>

</template>

<script>
export default {
  
  data() {
    return {

      searchQuery: ""
      
      }

  },

computed: {
    events(){
      
      let myEvents = this.$store.state.allEvents.filter
      (event => event.hostId === this.$store.state.account.homeAccountIdentifier);

      console.log(myEvents);

      if(this.searchQuery !== "") {
        
        myEvents =  myEvents.filter
        (event => event.name.toLowerCase().includes(this.searchQuery.toLowerCase()));
    
            console.log(myEvents);
        } 
        
       
          this.$store.commit(setFilteredEventsByLetter;
     },
    
},

async created() {
      await this.$store.dispatch('fetchEvents');

    }
}
</script>

<style>

</style>