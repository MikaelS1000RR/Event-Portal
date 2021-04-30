<template>
  
  <div class="form-grid-container">
   
    <v-app>
<div class="grid">
       <v-card width="500px" class="mt-5 mx-a">
         <v-card-title class="pb-0">
        <h1>Login</h1>
         </v-card-title>
         <v-card-text>
         <v-form>
           <v-text-field 
           label="Username" 
           prepend-icon="mdi-account-circle"
           />
           <v-text-field
           :type="showPassword ? 'text' : 'password'"
           label="Password"
           prepend-icon="mdi-lock"
           :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
           @click:append="showPassword = !showPassword"
           />
         </v-form>
         </v-card-text>
         <v-divider></v-divider>
         <v-card-actions>
         <v-btn :color="type==='guest' ? 'secondary' : '#a64dff'">Register</v-btn>
         <v-spacer></v-spacer>
         <v-btn :color="type==='guest' ? 'secondary' : '#9933FF'">Login</v-btn>
         </v-card-actions>
    </v-card>
</div>
  </v-app>
    </div>
       

</template>

<script>

export default {
  name: "LoginForm",
  data() {
    return {
      showPassword: false
    }
  }
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







</style>