<template>
  <div class="main-sidebar h-100 d-flex flex-direction-column justify-space-between">
    <div class="main-sidebar-content">
      <ul class="d-flex flex-direction-column">
        <li>
          <div class="icon icon-recruitment-news mr-10"></div>
          <div>Tin tuyển dụng</div>
        </li>
        <li>
          <div class="icon icon-candidate mr-10"></div>
          <div>Ứng viên</div>
        </li>
        <li>
          <div class="icon icon-calendar mr-10"></div>
          <div>Lịch</div>
        </li>
        <li>
          <div class="icon icon-potential-pool mr-10"></div>
          <div>Kho tiềm năng</div>
        </li>
        <li>
          <div class="icon icon-recruitment-campaign mr-10"></div>
          <div>Chiến dịch tuyển dụng</div>
        </li>
        <li>
          <div class="icon icon-job mr-10"></div>
          <div>Công việc</div>
        </li>
        <li>
          <div class="icon icon-ai-marketing mr-10"></div>
          <div>aiMakerting</div>
        </li>
        <li>
          <div class="icon icon-candidate-chat mr-10"></div>
          <div>Trao đổi với ứng viên</div>
        </li>
        <li>
          <div class="icon icon-report mr-10"></div>
          <div>Báo cáo</div>
        </li>
        <li>
          <div class="icon icon-settings mr-10"></div>
          <div>Thiết lập</div>
        </li>
        <li>
          <div class="icon-link icon-knowledge mr-10"></div>
          <div>Kiến thức hữu ích</div>
        </li>
      </ul>
    </div>
    <div class="main-sidebar-action d-flex align-center justify-center">
      <button class="main-sidebar-btn cursor-pointer">
        <div class="icon icon-collapse mr-10"></div>
        <div>Thu gọn</div>
      </button>
    </div>
  </div>
</template>

<style scoped>
/* Main sidebar*/
.main-sidebar {
  min-width: 233px;
  background-image:
    linear-gradient(to bottom, rgba(0, 0, 0, 0.8), rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.2)),
    url('../assets/icons/bg-sidebar.svg');
  background-size: contain;
  background-position: center bottom;
  /* background-color: yellow; */
  background-repeat: no-repeat;
  padding: 32px 0 16px;
}

/* Content sidebar */
.main-sidebar-content {
  list-style: none;
  color: #c5ccd5;
  font-weight: 700;
}

.main-sidebar-content li {
  display: flex;
  font-size: 14px !important;
  align-items: center;
  margin: 0 12px 12px;
  padding: 8px 12px;
}

.main-sidebar-content li:hover {
  color: #ffffff;
}

.main-sidebar-btn {
  display: flex;
  align-items: center;
  color: #ffffff;
  width: 180px;
  height: 40px;
  outline: none;
  border: none;
  border-radius: 5px;
  background-color: rgba(255, 255, 255, 0.1);
}

.main-sidebar-btn .icon-collapse {
  background-color: #ffffff;
}
</style>