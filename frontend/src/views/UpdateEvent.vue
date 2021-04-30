<template>
  <div class="update-wrapper">
   
     <form @submit.prevent="saveChanges">
       <v-card :loading="loading" class="mx-auto my-12" outlined shaped tile>
   
    

        <div class="event-details">
        <div class="event-info">
          <ul>
            <li>
               

        <img class="detailedImg" src="https://www.flaticon.com/svg/vstatic/svg/1250/1250252.svg?token=exp=1619784941~hmac=be8b5c2880fd0496925c51adf3f5f626" alt="">
          <input type="text" v-model="eventName" />
      

       
            </li>
            <li>
              <img
                class="detailedImg"
                src="https://www.flaticon.com/svg/vstatic/svg/4585/4585617.svg?token=exp=1619724567~hmac=1a64feb6ca9b8ef9acc92eb3c6aeb715"
                alt=""
                srcset=""
              />
              <input type="text" placeholder="" v-model="name">
            </li>

            <li>
              <img
                class="detailedImg"
                src="https://www.flaticon.com/svg/vstatic/svg/4585/4585180.svg?token=exp=1619724673~hmac=b51eed2d5d6b2ff03b8cefd7e5e93b61"
                alt=""
                srcset=""
              />

            <input type="text" placeholder="" v-model="name">
            </li>

            <li>
              <img
                class="detailedImg"
                src="https://www.flaticon.com/svg/vstatic/svg/4585/4585147.svg?token=exp=1619724730~hmac=bab92bca9cca01f2c559c82059f750b5"
                alt=""
                srcset=""
              />

              <input type="text" placeholder="" v-model="name">
            </li>


            <li>
             
                 <label for="public">Public</label>
        <img class="door" src="../assets/door.png">
        <input id="public" value="Public" type="checkbox" v-model="publicAccess"  @change="disablePrivate">
        
            
        <label for="private" class="lock-label">Private</label>
        <img class="lock" src="../assets/lock.png">
        <input  id="private" value="Private" type="checkbox" v-model="privateAccess" @change="disablePublic">
            
            </li>
          </ul>
          </div>
        </div>
         

           <div class="event-desc">
          <div class="description">
            <p>Description</p>
          </div>

          <p>{{ currEvent.description }}</p>



          
        </div>
     
    
    </v-card>
     </form>
     </div>
  
</template>

<script>

export default {

  data(){
   return{
      eventName: '',
      location: '',
      startTimeAndDate: '',
      endTimeAndDate: '',
      description: '',
     publicAccess: true,
      privateAccess: false,
      access: "",
      hostId: '061eb70c-7055-4d07-a584-b3c20cd59d73'
   }
  },
   methods:{
     saveChanges(){
       console.log('saving changes');
     },
       disablePublic(){
     this.publicAccess=false;
   },
   disablePrivate(){
     this.privateAccess=false;
   },
   },
  computed: {
    currEvent() {
      
      return this.$store.state.specEvent;
    },
   
  }

}
</script>

<style scoped>

.update-wrapper{
  width:100%;
  height:100vh;
  color:white;
 
}

.detailedImg {
  width: 8%;
}



.my-12 {
  width: 90vw;

  background-color: white;
  display: grid;
  grid-template-columns: repeat(2, 1fr);

  padding-right: 2vw;
}


ul {
  list-style-type: none;
}

ul > li {
  display: flex;
  flex-direction: row;
  padding: 1.5vw;
  align-items: center;
  text-align: center;
}

li > p {
  margin-top: 1.2vw;
  padding-left: 1vw;
  font-size: 1.2vw;
}


.door {
  width: 12%;
  

}
.lock-label{
  margin-left:2.5vw;
}

.lock {
  width: 10%;


}

</style>