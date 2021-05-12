<template>
  <div class="wrapper">
   
     <div class="filter-wrapper">
        
      
        <v-col
          cols="12"
          sm="18"
        >
          <v-select
            v-model="value"
            :items="items"
           filled
            chips
           
            multiple
            @change="filterEvents"
          ></v-select>
        </v-col>

            <v-dialog v-model="dialog" width="500">
              

              <v-card>
                <v-card-title class="headline grey lighten-2">
                  You do not have permission to view private events
                </v-card-title>
                 <v-card-text>Please log in or register first in order to see private events</v-card-text>

                <v-divider></v-divider>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="primary" text @click="dialog=false">
                   Ok
                  </v-btn>
                 
                </v-card-actions>
              </v-card>
            </v-dialog>
       
    </div>
        
    <div class="event-list">
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>
  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";
export default {
  data(){
    return{
      items: ['All events', 'My events'],
      value: ['All events', 'My events'],
      dialog: false,
     
    }
    
  },
  methods:{
  async  filterEvents(){
    console.log(this.value);
   
    if(this.value.includes("All events")){
  
   
      await this.$store.dispatch("fetchEvents", this.value)
        

      } 
      else if(this.value.includes("My events")) {
         await this.$store.dispatch("fetchEvents", this.value)
      }
    }
  },
  components: {
    EventItem,
  },
  computed: {
     events(){
       return this.$store.state.events
     }
  },

};
</script>

<style scoped>
.wrapper {
  width: 100%;

  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.event-list {
  width: 95%;
  padding-top: 3vw;
  display: grid;
  grid-template-columns: repeat(3, 1fr);

  justify-content: center;

  position: relative;
}


.filter-wrapper{


 padding: 0 1vw 0 1vw;
 margin-top:2vh;
 
 color:white !important;
 align-self: flex-end;
 margin-right:6vw;
}


.col-sm-12 {
  font-weight: bold;
  color:white;
  border-radius: 10px;
}



.v-application .grey.lighten-2 {
  background-color: var(--buttonPurpleSecondary) !important;
}

.v-dialog > .v-card > .v-card__title {
  font-size: 1.1em !important;
  font-family: "Montserrat", sans-serif !important;
}

.v-dialog > .v-card > .v-card__text{
  padding-top:1vh;
}
@media only screen and (max-width: 950px) {
  .event-list{
    grid-template-columns: repeat(2, 1fr);
  }
}

@media only screen and (max-width: 560px) {
 .event-list{
    grid-template-columns: 1fr;
  }
}

</style>
