<template>
  <div class="form-grid-container">
   
    <v-app>
<div class="grid">


     <v-card width="500px" class="mt-5 mx-a">
         <v-card-title class="pb-0">
          <h2 class="join-as-guest">Join as Guest</h2>
          <v-card-text>
         <v-form @submit.prevent="pressed">
           <v-text-field 
  
           label="Username" 
           prepend-icon="mdi-account-circle"
           />
           <v-card-actions>
              <v-btn class="join-btn" 
              type="submit"
              >JOIN</v-btn>
               </v-card-actions>
               </v-form>
              </v-card-text>
              <v-divider></v-divider>
              
            </v-card-title>
  
                     <v-card-title class="pb-0">
          <h2 class="join-as-guest">OR</h2>
          <v-card-text>
              </v-card-text>
              <v-divider></v-divider>
              
            </v-card-title>
          
<v-card-actions>
         <v-btn class="login" type="submit" :color="type==='guest' ? 'secondary' : '#9933FF'">Login</v-btn>
         <div class="error" v-if="error">{{error.message}}</div>
        
         </v-card-actions>

            </v-card>



  
</div>
  </v-app>
    </div>
       

</template>

<script>
export default {

  

}
</script>

<style scoped>


.grid {
 
display: grid;
  justify-items: center;
  align-items: center;
 grid-template-columns: 1fr;
  grid-template-rows: 70vh;


}

.join-as-guest {
  margin-left: auto;
   margin-right: auto;
}


.login {
  width: 30%;
    margin-left: auto;
   margin-right: auto;
}

.join-btn {
  margin-left: auto;
   margin-right: auto;
   

}




</style>