<template>
  <v-app>
    
    <v-container class="mt-15">
      <v-card class="text-center listform">
        <v-row class="listtitle">
        <v-col >
            聯絡人
          </v-col>
          <v-col>
            聯絡信箱
          </v-col>
          <v-col>
            信件內容
          </v-col>
          <v-col>
            發送日期
          </v-col>
          <v-col>
            發送時間
          </v-col>
        </v-row>

      <v-row v-for="item in items" :key="item.Mail" class="center list">
      
        <v-col>
          {{item.name}}
        </v-col>
        <v-col>
          {{item.mail}}
        </v-col>
        <v-col>
          {{item.message}}
        </v-col>
        <v-col>
          {{item.date}}
        </v-col>
        <v-col>
          {{item.time}}
        </v-col>
        
      </v-row>
     
      </v-card>
      
    </v-container>
    <div class="center">
     <v-btn 
       
        @click="Update()"
        class="mt-10 bt_update"               
      >更新</v-btn>
    </div>
  </v-app>
</template>

<style scoped>
   .center{
    display: flex;
    justify-content: center; 
    align-items: center; 
  }

  .listform{
    width: 60%;
  }

  .bt_update{
    width: 80px;
  }

  .listtitle{
    background-color: rgb(104, 127, 190) !important;
    color: white !important;
   
  }
</style>

<script>
import {apiGetAll} from '../utils/request'
export default {
  name: 'MailList',
  components: {
   
  },
   data () {
      return {
        items:[]
        
      }      
  },
  created(){
    apiGetAll().then((res)=>{
      this.items = res.data
      }).catch((ex)=>alert("載入失敗"+ex))
    
  },
  methods:{
    Update(){
     apiGetAll().then((res)=>{
      this.items = res.data
      }).catch((ex)=>alert("載入失敗"+ex))
    }

  },
  watch:{
    items:function(){

    }
  }
}
</script>